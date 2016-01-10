#!/bin/bash

#Pretty simple shell script to do much of the basic CyberPatriot Ubuntu tasks.
#Will run updates, create an HTML page with every user and folder and the amount of memory they each use and a list of default Ubuntu programs, force update Firefox and Libre Office, and set a password policy.
#TODO: Add a list of default Ubuntu 14.04 processes, configure the firewall, and run the virus scanner on the scripts exit.
#Written for Ubuntu 14.04! No guarantee it will work in earlier or later versions!!
#DO THE FORENSICS QUESTIONS FIRST!!!

##### Constants

TITLE="System Information for $HOSTNAME"
RIGHT_NOW=$(date +"%x %r %Z")
TIME_STAMP="Updated on $RIGHT_NOW by $USER"

##### Set by user

##### Functions

function show_uptime
{
	echo "<h2>System uptime</h2>"
	echo "<pre>"
	uptime
	echo "</pre>"
}


function drive_space
{
	echo "<h2>Filesystem space</h2>"
	echo "<pre>"
	df
	echo "</pre>"
}


function home_space
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

function program_list
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

function process_list
{
	echo "<pre>Not done yet.</pre>"
}


function write_page
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
		$(program_list)
		$(process_list)
		</body>
	</html>
_EOF_
}

function edit_passwd_policy
{
	if grep -q "minlen" "/etc/pam.d/common-password"; then
		sed -i 's/minlen=.*/minlen=12/' "/etc/pam.d/common-password"
	else
		sed -i 's/sha512/sha512 minlen=12/' "/etc/pam.d/common-password"
	fi
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

echo "$(tput setaf 2)Updating$(tput sgr0)"
sudo apt-get update
echo "$(tput setaf 2)Upgrading$(tput sgr0)"
sudo apt-get upgrade

echo "$(tput setaf 2)Firefox is sometimes a little bitch and won't update with everyone else, cause it wants to be a special little snowflake$(tput sgr0)"
sudo apt-get --purge --reinstall install firefox
echo "$(tput setaf 2)Same with Libre Office$(tput sgr0)"
echo "$(tput setaf 2)Adding Libre Office repository$(tput sgr0)"
sudo add-apt-repository -y ppa:libreoffice/ppa
echo "$(tput setaf 2)Updating again$(tput sgr0)"
sudo apt-get update
echo "$(tput setaf 2)Installing Libre Office$(tput sgr0)"
sudo apt-get install libreoffice

echo "$(tput setaf 2)Updates are done!\nTime to do password policy$(tput sgr0)"
edit_passwd_policy
echo "$(tput setaf 2)Done with password policy!$(tput sgr0)"
write_page > AfterRunning.html

echo "$(tput setaf 2)You might have to remove the old version of Libre Office.${reset}"
echo "$(tput setaf 2)And I suggest double checking common-password in /etc/pam.d${reset}"
echo "$(tput setaf 2)Also, check cron jobs, update settings, and programs that exist but shouldn't.$(tput sgr0)"
