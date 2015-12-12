package lists;

import java.math.BigInteger;
import java.util.Random;

public class TestObject {
	private static Random rand = new Random();
	public TestObject(){
		I = rand.nextInt();
		D = rand.nextDouble();
		S = new BigInteger(100, rand).toString();
	}
	public String toString(){
		return I+" "+D+" "+S; 
	}
	public TestObject(int i, double d, String s){
		I = i;
		D = d;
		S =s;
	}
	private int I;
	public int getI() {
		return I;
	}
	public void setI(int i) {
		I = i;
	}
	public double getD() {
		return D;
	}
	public void setD(double d) {
		D = d;
	}
	public String getS() {
		return S;
	}
	public void setS(String s) {
		S = s;
	}
	private double D;
	private String S; 
}
