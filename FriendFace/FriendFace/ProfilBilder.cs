﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendFace
{
    internal class ProfilBilder
    {
        private string[] images;

        public ProfilBilder()
        {
            images = new string[]
            {
                @"
                     ,-`-.
                  ,' .___;
                 /_ ,'@@,-. 
                 (C`____ -'
                  \ `--' ;
                   ``:`:'
                  .-`  '--.
                 ( /7   \7 )
                  \\i--._|/
                 (,-,)   |
                 ,--:_.  /
                (  ..__,/
                 `-' ;  ``.
                      `---`
                 ",
                 @"
                       / ,
                  /\  \|/  /\
                  |\\_;=._//|
                   \.""   ""./
                   //^\ /^\\
            .'``"",/ |0| |0| \,""``'.
           /   ,  `'\.---./'`  ,   \
          /`  /`\,.""(     )"".,/`\  `\
          /`     ( '.'-.-'.' )     `\
          /""`     ""._  :  _.""     `""\
           `/.'`""=.,_``=``_,.=""`'.\`
                      )   (
                        ",
                @" 
                   _  .   .   .
                 .' '; '-' '-'|-.
                (     '------.'  )
                 ;            \ /
                  :     '   ' |/
                  '._._       \    .;
                 .-'   ;--.    '--' /
                /      \-'---.___.'
               |     / 7 \(>o<) /\
               |     | \ |  . \   \
               |=====|   |  .  \ |-)
                |-'-'   ./_.-._.\|
                '-.----'        |
                  |       |     |
                  |     | |   | |
                  |_____|_|___|_|
                  (-------',----'.
                   '-'-----'-----'
                ",
                @"
                    ___ 
                .-``   ``-.
              .'           '.
             /               \
            |      __ __      |
            '      /\_/\      '
             \  ___\O_O/___  /
              \/    ___    \/
              (    (___)    )
               \   /\_/\   /
                \  |._.|  /
                 \ |   | /
                  \/   \/
                ",
                @"
                 .-'-.
               /`     |__
             /`  _.--`-,-`
             '-|`   a '<-.   []
               \     _\__) \=`
                C_  `    ,_/
                  | ;----'
                "
            };

        }

        public string[] GetImage()
        {
            return images;
        }
    }
}
