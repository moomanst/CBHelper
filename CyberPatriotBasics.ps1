#Requires -RunAsAdministrator

function enableFirewall
{
    Write-host 'Enabling Windows firewall'
    $win8 = Read-host 'Are you on Windows 8 or Server 2012 or newer (y/n)?'
    if ($openUpdate -eq 'y') {
        # For Win8 and newer/Server 2012 and newer
        Set-NetFirewallProfile -Profile Domain,Public,Private -Enabled True
    }
    else {
        #For older OSes
        netsh advfirewall set allprofiles state on
    }
}

function disableGuestAccount
{
    Write-host 'Disabling Guest account'
    C:\Windows\System32\cmd.exe /C net user Guest /active:no
}

function setUserPasswords
{
    Write-host 'Do you want to set all user passwords to "Wy*LuLjW8*SUT^YE" (y/n)?'
    $set_passwords = read-host 'WARNING:  This is a fast way to get CyberPatriot points, but IT SHOULD NEVER BE DONE ON A PRODUCTION MACHINE!'
    if ($set_passwords -eq 'y') {
	    $password = 'Wy*LuLjW8*SUT^YE' # set what the user password will be (you can change this)
	    $accounts = get-wmiobject Win32_UserAccount -filter 'LocalAccount=TRUE' | select-object -expandproperty Name # get a list of user accounts

	    foreach ($i in $accounts) {
		    if ($i -eq 'HomeGroupUser$') { continue } # Don't need to worry about the homegroup user
		    C:\Windows\System32\cmd.exe /C net user $i $password # Set the user password to the password defined above
		}
	}
}

function enableWindowsUpdate
{
    Write-host 'Enabling automatic updating and including recommended updates'
    $updateObject = (New-Object -com "Microsoft.Update.AutoUpdate").Settings
    # Turn on AutoUpdate
    $updateObject.NotificationLevel = 4
    $updateObject.IncludeRecommendedUpdates = "true"
    $updateObject.save()
    $openUpdate = Read-host 'Do you wish to check for updates now (y/n)?'
    if ($openUpdate -eq 'y') {
        # Open Control Panel to Windows Update
        control update
    }
}

function setLocalSecurityPolicies
{
    Write-host 'Set account lockout to 5'
    C:\Windows\System32\cmd.exe /C net accounts /lockoutthreshold:5
    Write-host 'Set min password length to 12, max age to 30, and history to 5'
    C:\Windows\System32\cmd.exe /C net accounts /MINPWLEN:12 /MAXPWAGE:30 /UNIQUEPW:5
    Write-host 'Remember to enable "Password must meet complexity requirements" under "Account Policies" -> "Password Policy".'
    Start-process secpol.msc -Wait
}

function setupAuditing
{
    Write-host 'Setting up auditing'
    # As of Windows 8
    $auditCategories = @("Account Logon", "Account Management", "Detailed Tracking", "DS Access", "Logon/Logoff", "Object Access", "Policy Change", "Privilege Use", "System")
    foreach ($i in $auditCategories) {
        C:\Windows\System32\cmd.exe /C auditpol.exe /set /category:"$i" /failure:enable
    }
}

function installFirefox
{
    Write-host 'Installing Firefox'
    $uri = "https://download.mozilla.org/?product=firefox-stub&os=win&lang=en-US"
    $out = "c:\FireFoxInstaller.exe"
    Invoke-WebRequest -Uri $uri -OutFile $out
    & $out /install=agent /silent /suppressmsgboxes
}

function installMalwarebytes
{
    Write-host 'Installing Malwarebytes'
    $uri  = 'https://downloads.malwarebytes.org/file/mbam_current/'
    $out = 'c:\malwaresetup.exe'
    Invoke-WebRequest -Uri $uri -OutFile $out

    & $out /install=agent /silent /suppressmsgboxes
}

function installMalwarebytesAntiRootkit
{
    Write-host 'Installing Malwarebytes Anti-Rootkit. It will automatically start running upon installing, but I suggest running Malwarebytes first.'
    $uri  = 'https://downloads.malwarebytes.org/file/mbar/'
    $out = 'c:\rootkitsetup.exe'
    Invoke-WebRequest -Uri $uri -OutFile $out

    & $out /install=agent /silent /suppressmsgboxes
}

function findMedia
{
    Write-host 'Attempting to find media'
    $items = Get-ChildItem -Path C:\Users\ -Include *.mp3, *.mp4, *.wma, *.mov, *.wmv, *.wav -Recurse
        Write-host "$items"
}

enableFirewall
disableGuestAccount
setUserPasswords
enableWindowsUpdate
setLocalSecurityPolicies
setupAuditing
installFirefox
installMalwarebytes
installMalwarebytesAntiRootkit
findMedia