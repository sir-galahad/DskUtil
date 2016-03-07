# DskUtil
a rather simple utility based on .net to read and write to disk images using Tandy's DECB Filesystem.

As of right now the code for DskUtil works to copy files from a .dsk image and writing files to a .dsk image. Still to do is a major refactoring (while things work all of the code needs a good deal of streamlining.) Functionality for deleting files and reclaiming directory entries from deleted files. Possibly functionality to defrag the dsk and to attempt to store files in as many consective granules as possible.

While my code seems to work just fine on my machine it would  be wise to make sure you have a back up copy of your .dsk before you attempt to write to it.
