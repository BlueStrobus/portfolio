//6. 섭씨 화씨

import java.util.Scanner;
public class CF6{

    public static void main(String[] args) { 
        
        // scanner 선언
        Scanner scanner = new Scanner(System.in);
 
        System.out.print("화씨(⁣F°)온도를 입력하세요 : ");
        int f1 = scanner.nextInt();

        double c1 = 5.0 / 9.0 * (f1-32);

        System.out.println(c1 + "°C");





    }

}
