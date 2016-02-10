#pragma once 
namespace Containers
{
	template <class T>
	class CircularBuffer final
	{
	public:
		typedef T value_type;
		typedef T* pointer;
		typedef const T* const_pointer;
		typedef T& reference;
		typedef const T& const_reference;

		explicit CircularBuffer(size_t);
		~CircularBuffer();

		reference front();
		reference back(); 
		const_reference front() const;
		const_reference back() const;

		void push_back(const_reference);
		void push_front(const_reference);
		void push_back(reference);
		void push_front(reference);
		void pop_front();
		void pop_back();

		void clear();
		bool empty() const;
		bool full() const;

		size_t size() const;
		size_t capacity() const;

		reference operator[](size_t);
		const_reference operator[](size_t) const;

	private:
		T* buffer;
		size_t head;
		size_t tail;
		size_t size_;
		const size_t capacity_;
		void increment(size_t&) const;
		void decrement(size_t&) const;
	};
	template <class T>
	CircularBuffer<T>::CircularBuffer(size_t size) : head(0), tail(0), size_(0), capacity_(size)
	{
		buffer = new T[size];
	}

	template <class T>
	CircularBuffer<T>::~CircularBuffer()
	{
		delete[] buffer;
	}

	template <class T>
	typename CircularBuffer<T>::reference CircularBuffer<T>::front()
	{
		return buffer[head];
	}

	template <class T>
	typename CircularBuffer<T>::reference CircularBuffer<T>::back()
	{
		return buffer[tail];
	}

	template <class T>
	typename CircularBuffer<T>::const_reference CircularBuffer<T>::front() const
	{
		return buffer[head];
	}

	template <class T>
	typename CircularBuffer<T>::const_reference CircularBuffer<T>::back() const
	{
		return buffer[tail];
	}

	template <class T>
	void CircularBuffer<T>::pop_front()
	{
		increment(head);
		--size_;
	}

	template <class T>
	void CircularBuffer<T>::pop_back()
	{
		decrement(tail);
		--size_;
	}


	template <class T>
	void CircularBuffer<T>::push_back(const_reference item)
	{
		if (empty())
		{
			buffer[0] = item;
			size_ = 1;
		}
		else {
			increment(tail);
			buffer[tail] = item;
			if (size_ == capacity_)
				increment(head);
			else
				size_++;
		}
	}
	template <class T>
	void CircularBuffer<T>::push_front(const_reference item)
	{
		if (empty())
		{
			buffer[0] = item;
			size_ = 1;
		}
		else {
			decrement(head);
			buffer[head] = item;
			if (size_ == capacity_)
				decrement(tail);
			else
				size_++;
		}
	}

	template <class T>
	void CircularBuffer<T>::push_back(reference item)
	{
		if (empty())
		{
			buffer[0] = item;
			size_ = 1;
		}
		else {
			increment(tail);
			buffer[tail] = item;
			if (size_ == capacity_)
				increment(head);
			else
				size_++;
		}
	}

	template <class T>
	void CircularBuffer<T>::push_front(reference item)
	{
		if (empty())
		{
			buffer[0] = item;
			size_ = 1;
		}
		else {
			decrement(head);
			buffer[head] = item;
			if (size_ == capacity_)
				decrement(tail);
			else
				size_++;
		}
	}

	template <class T>
	void CircularBuffer<T>::clear()
	{
		head = tail = size_ = 0;
	}

	template <class T>
	bool CircularBuffer<T>::empty() const
	{
		return	size_ == 0;;
	}

	template <class T>
	bool CircularBuffer<T>::full() const
	{
		return size_ == capacity_;
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
		size_t i = (head + index) % capacity_;
		if (i > capacity_ - 1)
			throw std::out_of_range("CircularBuffer<T>::operator[] : index is out of range");
		return buffer[i];
	}

	template <class T>
	typename CircularBuffer<T>::const_reference CircularBuffer<T>::operator[](size_t index) const
	{
		size_t i = (head + index) % capacity_;
		if (i > capacity_ - 1)
			throw std::out_of_range("CircularBuffer<T>::operator[] : index is out of range");
		return buffer[i];
	}

	template <class T>
	void CircularBuffer<T>::increment(size_t& i) const
	{
		if (++i == capacity_)
			i = 0;
	}
	template <class T>
	void CircularBuffer<T>::decrement(size_t& i) const
	{
		if (--i == -1)
			i = capacity_ - 1;
	}
}

