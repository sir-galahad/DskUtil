# DskUtil
a rather simple utility based on .net to read and write to disk images using Tandy's DECB Filesystem.

As of right now the code for DskUtil works to copy files from a .dsk image and writing files to a .dsk image. Still to do is a major refactoring (while things work all of the code needs a good deal of streamlining.)

While my code seems to work just fine on my machine it would  be wise to make sure you have a back up copy of your .dsk before you attempt any write operations to it.

Note: If like me you're using this utility in tandem with an an emulator (i use xroar) it should be noted, this program holds the dsk file open so if you want to write to a .dsk that is open in this utility you must close the file in DskUtil first.
