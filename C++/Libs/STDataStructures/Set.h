#pragma once
#include "ICollection.h"
/*
	Auto resizable set
*/
template <typename T>
class Set :
	public ICollection<T>
{
public:
	typedef Set<T>* setPointer;
	typedef const Set<T>* constSetPointer;

	Set(size_t size) :Set(0, size)
	{}
	Set() :Set(0, 0)
	{}
	virtual ~Set()
	{}
	bool add(reference);
	bool add(constReference);
	bool addAll(basePointer);
	bool addAll(constBasePointer);
	bool addAll(setPointer);
	bool addAll(constSetPointer);


	void clear();
	bool contains(T);
	bool containsAll(ICollection<T>*);
	bool isEmpty();
	bool remove(T);
	bool removeAll(ICollection<T>*);
	size_t size() { return size_; }
	T* toArray();
private:
	Set(size_t size, size_t maxSize) :size_(size), maxSize_(maxSize)
	{
		data = new T[maxSize];
	}
	void realloc(size_t current, size_t expected);
	size_t size_;
	size_t maxSize_;
	T* data;
};

