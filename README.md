# Shadow Runner

Shadow Runner is a Windows console application that runs other console applications in a shadow copy mode.  Operating on a copy of your application allows you to update or replace it while because the files are not locked.

A common use case for this a console application that is run on a schedule using Windows task scheduler and you want to be able to relase updates to the console code but you either don't want to or can't disable the scheduled task.

# Usage

Execute the ShadowRunner.exe from a command line without any arguments to display the usage help.
