public static class DataHelper
{
    // Static field to hold the value
    private static string _toLocation;
    private static string _fromLocation;


    // Static property to get or set the value
    public static string ToLocation
    {
        get => _toLocation;
        set => _toLocation = value;
    }
    public static string FromLocation
    {
        get => _fromLocation;
        set => _fromLocation = value;
    }
}
