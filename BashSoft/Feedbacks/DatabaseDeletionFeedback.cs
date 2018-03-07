public class DatabaseDeletionFeedback : Feedback
{
    public override string Message => " Please execute the LOADDB command again to populate the database.";
    public override string BeginMessage => " Erasing database...";
    public override string EndMessage => " Done. All database records were removed.";
}
