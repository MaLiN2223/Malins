import static org.junit.Assert.*;

import org.junit.Test;

public class Tests {

	@Test
	public void AdditionTest(){
		final int size = 30;
		TestObject[] objects = new TestObject[size];
		DoubleLinkedList<TestObject> list = new DoubleLinkedList<>();
		for(int i =0;i<size;++i){
			list.add(objects[i]);
		} 
	}@Test
	public void AdditionTest2(){
		final int size = 30;
		TestObject[] objects = new TestObject[size];
		DoubleLinkedList<TestObject> list = new DoubleLinkedList<>();
		for(int i =0;i<size;++i){
			list.add(0,objects[i]);
		}
		for(int i =0;i<size;++i){
			
		} 
	}
	@Test
	public void test() {
		fail("Not yet implemented");
	}

}
