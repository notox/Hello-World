import org.joda.time.DateTime;
import org.joda.time.format.DateTimeFormat;
import org.joda.time.format.DateTimeFormatter;

import java.text.SimpleDateFormat;
import java.util.Date;

public class HelloTime {
    public static void main(String[] args) {
        Date defaultDate = new Date();
        System.out.println("The util's default date: " + defaultDate.toString());

        Date firstDayOf2013 = new Date(113, 0, 1);
        System.out.println("The util's first day of 2013: " + firstDayOf2013.toString());

        String formatedDate = new SimpleDateFormat("yyyy.MM.dd").format(firstDayOf2013).toString();
        System.out.println("The util's formated day: " + formatedDate);

        DateTime firstDayOf2013WithJoda = new DateTime().withDate(2013, 1, 1);
        System.out.println("The joda's first day of 2013: " + firstDayOf2013WithJoda.toString());

        DateTimeFormatter formatter = DateTimeFormat.forPattern("yyyy.MM.dd");
        String formatedDateByJoda = formatter.print(firstDayOf2013WithJoda);
        System.out.println("The joda's formated day: " + formatedDateByJoda);

    }
}
