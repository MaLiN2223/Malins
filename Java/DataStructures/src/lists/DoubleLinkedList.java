package lists;

import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

public class DoubleLinkedList<T> implements List<T> {
	private Node head = null;
	private Node tail = null;
	private int counter = 0;

	private class Node {
		public Node(T data) {
			this.data = data;
		}

		Node next;
		Node prev;
		T data;
	} 

	@Override
	public boolean add(T element) {
		if (head == null) {
			head = new Node(element);
			tail = head;
			counter++;
		} else {
			Node current = head;
			while (current.next != null) {
				current = current.next;
			}
			Node node = new Node(element);		
			current.next = node;
			node.prev = current; 
			tail = current;
			counter++;
		}
		return true;
	}

	@Override
	public void add(int index, T element) {
		if (index < 0)
			throw new IndexOutOfBoundsException("Index must be non-negative");
		if (index > counter)
			throw new IndexOutOfBoundsException("Index must be smaller or equal to collection size");
		Node newNode = new Node(element);
		if (head == null) {
			head = newNode; 
			tail = newNode;
		} 
		else if(index==counter){
			add(element);
			return;
		}
		else if(index==0){ 
			head.prev = newNode;
			newNode.next = head;
			newNode.prev = null;
			head = newNode;
		}
		else { 
			Node current = head;
			for(int i =0;i<index-1;++i){
				current =current.next;
			}
			newNode.next = current.next;
			current.next.prev = newNode;
			newNode.prev = current;
			current.next = newNode;
		}
		counter++;
	}

	@Override
	public boolean addAll(Collection<? extends T> arg0) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean addAll(int arg0, Collection<? extends T> arg1) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public void clear() {
		head = null;
		tail =null;
		counter = 0;
	}

	@Override
	public boolean contains(Object arg0) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean containsAll(Collection<?> arg0) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public T get(int arg0) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public int indexOf(Object arg0) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public boolean isEmpty() {
		return counter == 0;
	}

	@Override
	public Iterator<T> iterator() {
		Iterator<T> iterator = new Iterator<T>() {
			Node current = head;

			@Override
			public boolean hasNext() { 
				return head!=null && current.next != tail;
			}

			@Override
			public T next() {
				T data = current.data;
				current = current.next;
				return data;
			}

		};
		return iterator;

	}

	@Override
	public int lastIndexOf(Object arg0) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public ListIterator<T> listIterator() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public ListIterator<T> listIterator(int arg0) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean remove(Object arg0) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public T remove(int arg0) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean removeAll(Collection<?> arg0) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean retainAll(Collection<?> arg0) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public T set(int arg0, T arg1) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public int size() {
		return counter;
	}

	@Override
	public List<T> subList(int arg0, int arg1) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Object[] toArray() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public <T> T[] toArray(T[] arg0) {
		// TODO Auto-generated method stub
		return null;
	}

}
