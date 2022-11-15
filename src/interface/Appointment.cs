class Appointment
{
  public string client;
  public string name;
  public string company;
  public bool isExtraWork;
  public DateTime moment;
  public string date;
  public string time;
  public string startTime;
  public int id;

  public Appointment(
    int id,
    string client,
    string name,
    string company,
    bool isExtraWork,
    string startHour
  ) {
    DateTime now = DateTime.Now;

    this.id = id;
    this.client = client;
    this.name = name;
    this.company = company;
    this.isExtraWork = isExtraWork;
    this.moment = DateTimeHelper.getNow();
    this.date = DateTimeHelper.getDateNow();
    this.time = DateTimeHelper.getTimeNow();
    this.startTime = startHour;
  }
}