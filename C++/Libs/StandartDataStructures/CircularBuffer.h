#pragma once
#include <iostream>

template<class T>
class CircularBuffer final
{
public:
	explicit CircularBuffer(size_t);
	~CircularBuffer();
	bool Push(T);
	T Pop();
	void clear();
private:
	T * buffer;
	size_t start;
	size_t end;
	const size_t size;
};


template <class T>
CircularBuffer<T>::CircularBuffer(size_t size) : start(0), end(0), size(size)
{
	if (size <= 0)
		throw std::bad_alloc();
	buffer = new T[size];
}

template <class T>
CircularBuffer<T>::~CircularBuffer()
{
	delete[] buffer;
}

template <class T>
bool CircularBuffer<T>::Push(T data)
{
	bool moved = false;
	if (start == end) {
		end++;
		moved = true;
	}
	buffer[start++] = data; 
	return !moved;
}

template <class T>
T CircularBuffer<T>::Pop()
{
	if(start!=end)
	{
		return buffer[end++];
	}
}

template <class T>
void CircularBuffer<T>::clear()
{
	start = end = 0;
}
