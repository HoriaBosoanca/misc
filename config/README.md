# Dependencies
i3 -> desktop environment + window manager \
light-dm -> desktop manager \
rofi -> app launcher
# Config files
Load i3 config: config -> ~/.config/i3/ \
Download terminal config: dconf dump /org/gnome/terminal/ > gnome_terminal_settings.txt \
Load terminal config: dconf load /org/gnome/terminal/ < gnome_terminal_settings.txt \
Rofi themes: https://github.com/davatorium/rofi-themes
