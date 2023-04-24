// 4.초 환산
//? 1시간 6분 40초%   왜 %가 같이 출력되요?

import java.util.Scanner;
public class Time4 {

    public static void main(String[] args) { 
        
        // scanner 선언
        Scanner scanner = new Scanner(System.in);
 
        System.out.print("초 단위 정수를 입력하세요 : ");
        int number = scanner.nextInt();

        int h = number / (60 *60) ;
        int m = number %3600 / 60 ;
        int s = number % 60;

        System.out.printf("%d시간 %d분 %d초",h,m,s);

        // close scanner
        scanner.close();
 
    }
    
}
