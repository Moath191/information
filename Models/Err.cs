namespace information.Models
{
    public class Err {
        public Err(){
            datex=DateTime.Now;
        }
public int Id{set;get;}
public string Location{set;get;}
public DateTime datex{set;get;}
public string Message{set;get;}
public string InnerMessage{set;get;}

    }
}