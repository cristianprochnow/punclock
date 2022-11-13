class Appointment
{
  public string client;
  public string name;
  public string company;
  public bool isExtraWork;
  public DateTime moment;
  public string date;
  public string time;
  public DateTime startMoment;
  public string startDate;
  public string startTime;

  public Appointment(
    string client,
    string name,
    string company,
    bool isExtraWork,
    DateTime moment,
    DateTime startMoment
  ) {
    string dateFormat = "dd/MM/yyyy";
    string timeFormat = "H:mm:ss";

    this.client = client;
    this.name = name;
    this.company = company;
    this.isExtraWork = isExtraWork;
    this.moment = moment;
    this.date = this.moment.ToString(dateFormat);
    this.time = this.moment.ToString(timeFormat);
    this.startMoment = startMoment;
    this.startDate = this.startMoment.ToString(dateFormat);
    this.startTime = this.startMoment.ToString(timeFormat);
  }
}