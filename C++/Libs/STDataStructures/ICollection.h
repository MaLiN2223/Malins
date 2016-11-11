#pragma once
template<typename T>
class ICollection {
public:
	typedef ICollection<T>* basePointer;
	typedef const ICollection<T>* constBasePointer;
	typedef const T& constReference;
	typedef T& reference;
	typedef T* poiner;
	typedef const T* constPointer;

	virtual ~ICollection(){}
	virtual bool add(T) = 0;
	virtual bool addAll(ICollection<T>*) = 0;
	virtual void clear() = 0;
	virtual bool contains(T) = 0;
	virtual bool containsAll(ICollection<T>*) = 0;
	virtual bool isEmpty() = 0;
	virtual bool remove(T) = 0;
	virtual bool removeAll(ICollection<T>*) = 0;
	virtual size_t size() = 0;
	virtual T* toArray() = 0;
};