//5.소문자 대문자

import java.util.Scanner;
// import java.util.*;
public class Char5 {
    public static void main(String[] args) {
        System.out.print("문자를 입력하세요(영어): ");
        Scanner sc = new Scanner(System.in);
        char c = sc.next().charAt(0);

        c = Character.toLowerCase(c); //"a"
        c = Character.toUpperCase(c); //"A"


        System.out.println(c);
    }
    
}
