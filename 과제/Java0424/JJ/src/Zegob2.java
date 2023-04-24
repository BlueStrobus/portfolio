
// 2.입력한 값의 제곱

import java.util.Scanner;
public class Zegob2 {
    public static void main(String[] args) { 
        
        // scanner 선언
        Scanner scanner = new Scanner(System.in);
 
        System.out.print("정수를 입력하세요 : ");
        int number = scanner.nextInt();

        System.out.println(number + "의 제곱은 " + number*number);

        // close scanner
        scanner.close();
 
    }
    
}
