class DateTimeHelper
{
  static public string dateFormat = "dd/MM/yyyy";
  // static public string timeFormat = "H:mm:ss";
  static public string timeFormat = "H:mm";

  static public DateTime getNow()
  {
    return DateTime.Now;
  }

  static public string getDateNow()
  {
    return DateTimeHelper.getNow().ToString(dateFormat);
  }

  static public string getTimeNow()
  {
    return DateTimeHelper.getNow().ToString(timeFormat);
  }
}