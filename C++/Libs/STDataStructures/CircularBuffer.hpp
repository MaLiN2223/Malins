#pragma once
#include "CircularBuffer.h"
template <class T>
CircularBuffer<T>::CircularBuffer(size_t size) : start(0), end(0), size_(0), capacity_(size)
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
void CircularBuffer<T>::push_back(const_reference item)
{
	increment_end();
	if (size_ == capacity_)
	{
		increment_start();
	}
	buffer[end] = item;
}

template <class T>
void CircularBuffer<T>::pop_front()
{
	increment_start();
}

template <class T>
void CircularBuffer<T>::clear()
{
	start = end = size_ = 0;
}

template <class T>
void CircularBuffer<T>::increment_end()
{
	++end;
	++size_;
	if (end == size)
		end = 0;
}

template <class T>
void CircularBuffer<T>::increment_start()
{
	++start;
	--size_;
	if (start == size)
		start = 0;
}

template <class T>
bool CircularBuffer<T>::empty() const
{
	return start == end;
}

template <class T>
bool CircularBuffer<T>::full() const
{
	return size_ >= capacity_;
}

template <class T>
size_t CircularBuffer<T>::size() const
{
	return size_;
}

template <class T>
size_t CircularBuffer<T>::capacity() const
{
	return capacity_;
}

template <class T>
T& CircularBuffer<T>::operator[](size_t index)
{
	int i = (start + index) >> capacity_;
	if (i < 0 || i > capacity_ - 1)
		throw std::out_of_range("CircularBuffer<T>::operator[] : index is out of range");
	return buffer[i];
}

template <class T>
typename CircularBuffer<T>::const_reference CircularBuffer<T>::operator[](size_t index) const
{
	int i = (start + index) >> capacity_;
	if (i < 0 || i > capacity_ - 1)
		throw std::out_of_range("CircularBuffer<T>::operator[] : index is out of range");
	return buffer[i];
}