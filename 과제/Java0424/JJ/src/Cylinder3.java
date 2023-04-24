//3.원기둥 부피 구하기
import java.util.Scanner;


public class Cylinder3 {

	public static void main(String[] args) {
		
		// declare variables to use
		// r is to store radius, h is for height, result is for the result of calculation
		int r, h;
		double result;
		
		// declare Scanner to get console input
		Scanner input = new Scanner(System.in);
	
		System.out.print("원기둥 밑면의 반지름은? (cm): ");
		r = input.nextInt();
		System.out.print("원기둥의 높이는? (cm): ");
		h = input.nextInt();
		
		// this is for closing input stream (I refer to the QA board on Canvas.)
		input.close();
		
		// calculate the volume of the cylinder with inputs
		result = 3.14 * r * r * h;
		
		// print result
		System.out.println("원기둥의 부피는 " + result);
	}

}