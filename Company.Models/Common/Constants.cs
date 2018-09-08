namespace Company.Models.Common
{
    public class Constants
    {
        public const string ShortDateFormat = "MM/dd/yyyy";
        public const string ShortDateTimeFormat = "MM/dd/yyyy hh:mm tt";

        public enum ObjectState
        {
            Current = 0,
            New = 1,
            Deleted = 2,
            Modified = 4
        }
    }
}