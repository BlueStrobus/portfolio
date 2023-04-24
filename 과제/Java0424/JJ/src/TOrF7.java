// 7.4랑 5로 나누기
import java.util.Scanner;

public class TOrF7 {
    public static void main(String[] args) { 
//        
        // scanner 선언
        Scanner scanner = new Scanner(System.in);
 
        System.out.println("정수를 입력하세요 : ");
        int num = scanner.nextInt();

        // // 1 
        // if (num%4 ==0 && num%5 ==0){
        //     System.out.println("4와 5로 나누어짐: true");
        // }
        // else {
        //     System.out.println("4와 5로 나누어짐: false");
        // }

        // //2
        // if (num%4 ==0 || num%5 ==0){
        //     System.out.println("4또는 5로 나누어짐: true");
        // }
        // else {
        //     System.out.println("4또는 5로 나누어짐: false");
        // }


        // //3
        // if (!(num%4 ==0 || num%5 ==0) != !(num%4 ==0 && num%5 ==0)){
        //     System.out.println("4나 5로 나누어지지만 두 수 모두로는 나누어지지 않음: true");
        // }
        // else {
        //     System.out.println("4나 5로 나누어지지만 두 수 모두로는 나누어지지 않음: false");
        // }
//

System.out.println("4와 5로 나누어짐: " +(num%5==0 && num%4==0));
System.out.println("4또는 5로 나누어짐: " +(num%5==0 || num%4==0));
System.out.println("4나 5로 나누어지지만 두 수 모두로는 나누어지지 않음: " +(num%5==0 ^ num%4==0));




    }
    
}
