// 9. 성적

import java.util.Scanner;
public class Credit9 {

    public static void main(String[] args) { 
        int a,b,c;
        
        // scanner 선언
		Scanner input = new Scanner(System.in);
	
		System.out.print("전공 이수 학점: ");
		a = input.nextInt(); //전공
        System.out.print("교양 이수 학점: ");
		b = input.nextInt(); //교양
        System.out.print("일반 이수 학점: ");
		c = input.nextInt(); //일반

        if (a+b+c>=140 && a>=70 &&((b==30&&c==30)||b+c>=80)){
            System.out.println("졸업 가능");
        }
        else{
            System.out.println("졸업 불가");

        }



    }
}