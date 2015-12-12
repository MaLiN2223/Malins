package lists;
import static org.junit.Assert.*;

import java.util.Iterator;
import java.util.LinkedList;
import java.util.Random;

import org.junit.Test;

public class DoubleLinkedListTests {
	final int size =900; 
	@Test
	public void add() {
		TestObject[] objects = new TestObject[size];
		for(int i =0;i<size;++i){
			objects[i] = new TestObject();
		}
		DoubleLinkedList<TestObject> list = new DoubleLinkedList<>();
		for (int i = 0; i < size; ++i) {
			list.add(objects[i]);
		} 
		int i =0;
		assertEquals(list.size(),size);
		for(TestObject t : list){
			assertEquals(t.getD(),objects[i].getD(),0);
			assertEquals(t.getI(),objects[i].getI()); 
			assertEquals(t.getS(),objects[i].getS());
			i++;
		}
	}
	@Test
	public void addFirst(){
		DoubleLinkedList<TestObject> list = new DoubleLinkedList<>();
		TestObject[] objects = new TestObject[size];
		for(int i =0;i<size;++i){
			objects[i] = new TestObject();
		}
		for(int i =0;i<size;++i){
			list.add(0,objects[i]);
		}
		int i =size-1;
		assertEquals(list.size(),size);
		for(TestObject t : list){ 
			assertEquals(objects[i].getD(),t.getD(),0);
			assertEquals(t.getI(),objects[i].getI()); 
			assertEquals(t.getS(),objects[i].getS());
			i--;
		}
	}	@Test
	public void addLast(){
		final int size = 30; 
		DoubleLinkedList<TestObject> list = new DoubleLinkedList<>();
		TestObject[] objects = new TestObject[size];
		for(int i =0;i<size;++i){
			objects[i] = new TestObject();
		}
		for(int i =0;i<size;++i){
			list.add(list.size(),objects[i]);
		}
		int i =0;
		assertEquals(list.size(),size);
		for(TestObject t : list){ 
			assertEquals(objects[i].getD(),t.getD(),0);
			assertEquals(t.getI(),objects[i].getI()); 
			assertEquals(t.getS(),objects[i].getS());
			i++;
		}
	}
	@Test
	public void addSomewhere(){
		Random random = new Random();
		DoubleLinkedList<TestObject> list = new DoubleLinkedList<>();
		LinkedList<TestObject> list2 = new LinkedList<>();
		TestObject[] objects = new TestObject[size];
		for(int i =0;i<size;++i){
			objects[i] = new TestObject();
		}
		for(int i =0;i<size;++i){
			int index=0 ;
			if(i>0)
				index = random.nextInt(list2.size());
			list2.add(index, objects[i]);
			list.add(index,objects[i]);
			assertEquals(list.size(),list2.size());
		} 
		assertEquals(list.size(),list2.size());
		Iterator<TestObject> iterator2 = list2.iterator();
		Iterator<TestObject> iterator = list.iterator();
		while(iterator2.hasNext()){
			TestObject one = iterator.next();
			TestObject second = iterator2.next();
			assertEquals(second.getD(),one.getD(),0);
			assertEquals(second.getI(),one.getI());
			assertEquals(second.getS(),one.getS());
		} 
	}
	@Test
	public void clear(){
		DoubleLinkedList<TestObject> list = new DoubleLinkedList<>();
		for(int i =0;i<size;++i){
			list.add(new TestObject());
		}
		list.clear();
		assertEquals(list.size(),0);
		assertEquals(list.iterator().hasNext(),false); 
	}
}
