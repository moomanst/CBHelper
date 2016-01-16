#!/bin/bash

# Shell script to do much of the basic CyberPatriot Ubuntu tasks.
# Will run updates, create an HTML page with every user and folder and the amount of memory they each use and a list of default Ubuntu programs, force update Firefox and Libre Office, and set a password policy.
# TODO: Add a list of default Ubuntu 14.04 processes.
# Written for Ubuntu 14.04! No guarantee it will work in earlier or later versions!!
# DO THE FORENSICS QUESTIONS FIRST!!!

##### Constants

TITLE="System Information for $HOSTNAME"
RIGHT_NOW=$(date +"%x %r %Z")
TIME_STAMP="Updated on $RIGHT_NOW by $USER"

##### Set by user

##### Functions

show_uptime()
{
	echo "<h2>System uptime</h2>"
	echo "<pre>"
	uptime
	echo "</pre>"
}

drive_space()
{
	echo "<h2>Filesystem space</h2>"
	echo "<pre>"
	df
	echo "</pre>"
}

home_space()
{
	echo "<h2>Home directory space by user</h2>"
	echo "<pre>"
	format="%8s%10s%10s   %-s\n"
	printf "$format" "Dirs" "Files" "Blocks" "Directory"
	printf "$format" "----" "-----" "------" "---------"
	if [ $(id -u) = "0" ]; then
		dir_list="/home/*"
	else
		dir_list=$HOME
	fi
	for home_dir in $dir_list; do
		total_dirs=$(find $home_dir -type d | wc -l)
		total_files=$(find $home_dir -type f | wc -l)
		total_blocks=$(du -s $home_dir)
		printf "$format" $total_dirs $total_files $total_blocks
	done
	echo "</pre>"
}

program_list()
{
	echo "<h2>Default programs on Ubuntu 14.04</h2>"
	echo "<h3>Libre Office and Firefox are allowed always.</h3>"
	echo "<pre>"
	echo "<h3>Accessories</h3>"
	echo "<ul>"
	echo "<li>Disks</li>"
	echo "<li>Time & Date</li>"
	echo "<li>Activities and Privacy Manager Tool</li>"
	echo "<li>Text Editor</li>"
	echo "<li>Terminal</li>"
	echo "<li>Font Viewer<li>"
	echo "<li>XTerm</li>"
	echo "<li>Archive Manager</li>"
	echo "<li>Bluetooth Transfer</li>"
	echo "<li>Calculator</li>"
	echo "<li>Deja Dup Backup Tool</li>"
	echo "<li>Character Map</li>"
	echo "<li>Contacts</li>"
	echo "<li>Help</li>"
	echo "</ul>"
	echo "<h3>Developer Tools</h3>"
	echo "<ul>"
	echo "<li>Python (v3.4) (I'M NOT CERTAIN ON THIS ONE)</li>"
	echo "<li>Printers</li>"
	echo "<li>xdiagnose</li>"
	echo "</ul>"
	echo "<h3>Graphics</h3>"
	echo "<ul>"
	echo "<li>Image Viewer (eog)</li>"
	echo "<li>Shotwell Photo Manager</li>"
	echo "<li>Print Preview</li>"
	echo "<li>Document Viewer</li>"
	echo "<li>Simple Scan</li>"
	echo "<li>Shotwell Photo Viewer</li>"
	echo "<li>Photo lens for Unity</li>"
	echo "</ul>"
	echo "<h3>Internet</h3>"
	echo "<ul>"
	echo "<li>Ubufox extension for Firefox</li>"
	echo "<li>Desktop Sharing</li>"
	echo "<li>Browser</li>"
	echo "<li>Empathy Internet Messaging</li>"
	echo "<li>Thunderbird Mail</li>"
	echo "<li>Remmina Remote Desktop Client</li>"
	echo "<li>Transmission BitTorrent Client (SHOULD PROBABLY DELETE THIS ANYWAY)</li>"
	echo "</ul>"
	echo "<h3>Office</h3>"
	echo "<ul><li>Google Drive scope for Unity</li></ul>"
	echo "<h3>Sound & Video</h3>"
	echo "<ul>"
	echo "<li>Cheese Webcam Booth</li>"
	echo "<li>Videos</li>"
	echo "<li>Brasero Disc Burner</li>"
	echo "<li>Rythmbox Music Player</li>"
	echo "</ul>"
	echo "<h3>Themes & Tweaks</h3>"
	echo "<ul>"
	echo "<li>Software & Updates</li>"
	echo "<li>Personal File Sharing</li>"
	echo "<li>Universal Access</li>"
	echo "<li>Power</li>"
	echo "<li>Bluetooth Device Setup</li>"
	echo "<li>Network</li>"
	echo "<li>Color</li>"
	echo "<li>Online Accounts</li>"
	echo "<li>Landscape Service</li>"
	echo "<li>User Accounts</li>"
	echo "<li>Passwords and Keys</li>"
	echo "<li>Software Updater</li>"
	echo "<li>Displays</li>"
	echo "<li>Input Method</li>"
	echo "<li>Bluetooth</li>"
	echo "<li>Brightness & Lock</li>"
	echo "<li>Details</li>"
	echo "<li>Startup Disk Creator</li>"
	echo "<li>Mouse & Touchpad</li>"
	echo "<li>Keyboard Input Methods</li>"
	echo "<li>Language Support</li>"
	echo "<li>Sound</li>"
	echo "<li>Text Entry</li>"
	echo "<li>Software & Updates</li>"
	echo "<li>Wacom Tablet</li>"
	echo "<li>Ubuntu Software Center</li>"
	echo "<li>Keyboard</li>"
	echo "<li>Appearance</li>"
	echo "<li>Online Accounts</li>"
	echo "</ul>"
	echo "<h3>Universal Access</h3>"
	echo "<ul>"
	echo "<li>Orca Screen Reader</li>"
	echo "<li>Onboard</li>"
	echo "</ul>"
	echo "<h3>Uncategorized (NEED TO DOUBLE CHECK)</h3>"
	echo "<ul>"
	echo "<li>GNOME System Monitor</li>"
	echo "<li>Unity Webapps QML Test Launcher</li>"
	echo "<li>IBus Pinyin Setup</li>"
	echo "<li>Keyboard Layout</li>"
	echo "<li>Evolution Data Server</li>"
	echo "<li>View File</li>"
	echo "<li>Power Statistics</li>"
	echo "<li>Account authorization</li>"
	echo "<li>Network</li>"
	echo "<li>Disk Image Mounter</li>"
	echo "<li>Reactivate HP Laser Jet...</li>"
	echo "<li>Disk Image Writer</li>"
	echo "<li>Access Prompt</li>"
	echo "<li>System Testing</li>"
	echo "<li>System Settings</li>"
	echo "<li>Compiz</li>"
	echo "<li>IBus Bopomofo Preferences</li>"
	echo "<li>Account update tool</li>"
	echo "<li>AptURL</li>"
	echo "</ul>"
	echo "<h3>There are also about 1728 technical items.</h3"
	echo "</pre>"
}

process_list()
{
	echo "<h2>Running Services</h2>"
	echo "<pre>"
		service --status-all | less -P "le Services"
	echo "</pre>"
}

user_groups()
{
	echo "<h2>Users in Special Groups</h2>"
	echo "<pre>"
	echo "Members of group 'adm':"
    grep adm /etc/group | cut -d ':' -f 4
    echo "Members of group 'root':"
    grep root /etc/group | cut -d ':' -f 4
    echo "Members of group 'sudo':"
    grep sudo /etc/group | cut -d ':' -f 4
	echo "</pre>"
}

write_page()
{
	cat <<- _EOF_
	<html>
		<head>
		<title>$TITLE</title>
		</head>

		<body>
		<h1>$TITLE</h1>
		<p>$TIME_STAMP</p>
		$(show_uptime)
		$(drive_space)
		$(home_space)
		$(user_groups)
		$(program_list)
		$(process_list)
		</body>
	</html>
_EOF_
}

set_users()
{
	for i in `more userlist.txt `
		do
		echo $i
		adduser $i
	done
}

set_passwords()
{
	for i in `more userlist.txt `
	do
		echo $i
		echo "+AcVd8$#C7yhnP=!uLY%" | passwd –-stdin "$i"
		echo; echo "User $username’s password changed!"
	done
}

set_update_settings()
{
    # these are the recommended settings set in software-properties-gtk
    apt_config=/etc/apt/apt.conf.d/10periodic
    echo "APT::Periodic::Update-Package-Lists \"1\";" > $apt_config
    echo "APT::Periodic::Download-Upgradeable-Packages \"1\";" >> $apt_config
    echo "APT::Periodic::AutocleanInterval \"0\";" >> $apt_config
    echo "APT::Periodic::Unattended-Upgrade \"1\";" >> $apt_config
    echo "Set apt update settings"
}

disable_ssh_root_login()
{
    if [[ -f /etc/ssh/sshd_config ]]; then
        sed -i 's/PermitRootLogin .*/PermitRootLogin no/g' /etc/ssh/sshd_config
    else
        echo "No SSH server detected so nothing changed"
    fi
    echo "Disabled SSH root login"
}

preserve_root_uid()
{
    if [[ $(grep root /etc/passwd | wc -l) -gt 1 ]]; then
        grep root /etc/passwd | wc -l
    else
        echo "$(tput setaf 2)UID 0 is reserved to root$(tput sgr0)"
    fi
}

remove_hacking_tools()
{
    apt-get autoremove --purge john metasploit netcat nmap hydra aircrack-ng
    echo "$(tput setaf 2)Hacking tools should be removed now$(tput sgr0)"
}

check_no_pass()
{
    sed -i s/NOPASSWD:// /etc/sudoers
    echo "$(tput setaf 2)Removed any instances of NOPASSWD in sudoers$(tput sgr0)"
}

edit_passwd_policy()
{
	if grep -q "minlen" "/etc/pam.d/common-password"; then
		sed -i 's/minlen=.*/minlen=12/' "/etc/pam.d/common-password"
	else
		sed -i 's/sha512/sha512 minlen=12/' "/etc/pam.d/common-password"
	fi
	
	sed -i.bak -e 's/PASS_MAX_DAYS\t[[:digit:]]\+/PASS_MAX_DAYS\t30/' /etc/login.defs
    	sed -i -e 's/PASS_MIN_DAYS\t[[:digit:]]\+/PASS_MIN_DAYS\t7/' /etc/login.defs
    	sed -i -e 's/PASS_WARN_AGE\t[[:digit:]]\+/PASS_WARN_AGE\t14/' /etc/login.defs
	
	check_no_pass
}

disable_root_account()
{
  passwd -l root
}

disable_guest_account()
{
    echo 'allow-guest=false' >> /etc/lightdm/lightdm.conf
}

#### Main


if [ $(id -u) != "0" ]; then
{
	echo "$(tput setaf 1)Please run as superuser$(tput sgr0)"
	exit 1
}
else
{
	echo "$(tput setaf 2)Let's do this$(tput sgr0)"
}
fi

echo "$(tput setaf 2)Printing BeforeRunning HTML page${reset}"
write_page > BeforeRunning.html

echo "$(tput setaf 2)Making sure only root has uid 0$(tput sgr0)"
preserve_root_uid

echo "$(tput setaf 2)Setting up users and passwords. Make sure to fix Admin passwords!${reset}"
set_users
set_passwords

echo "$(tput setaf 2)Setting update settings$(tput sgr0)"
set_update_settings

echo "$(tput setaf 2)Updating$(tput sgr0)"
apt-get update
echo "$(tput setaf 2)Upgrading$(tput sgr0)"
apt-get upgrade

echo "$(tput setaf 2)Firefox is sometimes a little bitch and won't update with everyone else, cause it wants to be a special little snowflake$(tput sgr0)"
apt-get --purge --reinstall install firefox
echo "$(tput setaf 2)Same with Libre Office$(tput sgr0)"
echo "$(tput setaf 2)Adding Libre Office repository$(tput sgr0)"
add-apt-repository -y ppa:libreoffice/ppa
echo "$(tput setaf 2)Updating again$(tput sgr0)"
apt-get update
echo "$(tput setaf 2)Installing Libre Office$(tput sgr0)"
apt-get --purge --reinstall install libreoffice

echo "$(tput setaf 2)Updates are done!$(tput sgr0)"
echo "$(tput setaf 2)Time to do password policy$(tput sgr0)"
edit_passwd_policy
echo "$(tput setaf 2)Done with password policy!$(tput sgr0)"

echo "$(tput setaf 2)Disabling root ssh login$(tput sgr0)"
disable_ssh_root_login

echo "$(tput setaf 2)Disabling Guest account$(tput sgr0)"
disable_guest_account

echo "$(tput setaf 2)Disabling root account$(tput sgr0)"
disable_root_account

echo "$(tput setaf 2)Removing common hacking tools$(tput sgr0)"
remove_hacking_tools

echo "$(tput setaf 2)Starting firewall$(tput sgr0)"
ufw enable

echo "$(tput setaf 2)Generating post-script HTML file$(tput sgr0)"
write_page > AfterRunning.html

echo "$(tput setaf 2)Finished everything else, time to run Clam$(tput sgr0)"
if [[ ! -d "/home/VIRUS" ]]
then
        if [[ ! -L "/home/VIRUS" ]]
        then
                echo "Directory doesn't exist. Creating now"
                mkdir "/home/VIRUS"
                echo "Directory created"
        else
                echo "Directory exists"
        fi
fi
apt-get install clamav
freshclam
echo "$(tput setaf 2)Scan started$(tput sgr0)"
clamscan -r --bell -i --move=/home/VIRUS /

echo "$(tput setaf 2)Scan done. Generating post-scan HTML file$(tput sgr0)"
write_page > AfterRunningScan.html

echo "$(tput setaf 2)And I suggest double checking common-password in /etc/pam.d and /etc/login.defs${reset}"
echo "$(tput setaf 2)Also, duoble check cron jobs, update settings, and programs/processes that exist but shouldn't.$(tput sgr0)"

exit 0
