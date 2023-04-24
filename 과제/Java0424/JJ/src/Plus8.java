//8. 자리릿수 합 구하기
import java.util.Scanner;


public class Plus8 {
    public static void main(String[] args) { 
 
        System.out.print("0과 999사이의 정수를 입력하세요 : ");
        // scanner 선언
        Scanner sc = new Scanner(System.in);
        int num = sc.nextInt();
        int sum = 0;

        if (num >=0 && num <= 999){

            //num을 100으로 나눈 값을 sum에 더한다.
            sum += num/100;
            //num을 10으로 나눈 나머지를 sum에 더한다.
            sum += num%100/10;
            //num을 10으로 나눈 나머지를 sum에 더한다.
            sum += num%10;

            System.out.println("각 자리수의 합= "+sum);
        }
        sc.close();

    }
}
//  555
// a= 5
// b = 5
// c = n%10