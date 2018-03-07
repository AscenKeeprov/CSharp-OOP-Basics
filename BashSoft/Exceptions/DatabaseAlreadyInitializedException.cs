using System;

public class DatabaseAlreadyInitializedException : Exception
{
    public override string Message => " Database has already been initialized! " +
	Environment.NewLine + " Delete existing records before loading new ones? (Y/N) ";
}
