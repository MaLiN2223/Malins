#pragma once
#include <deque>
namespace containers {
	/**
	* Generic array based stack
	*/
	template<class T, class Container = std::deque<T>>
	class stack
	{
	public:
		typedef T& reference;
		typedef const T& const_reference;
		explicit stack();
		bool empty();
		size_t size();
		reference top();
		const_reference top() const;
		void push(reference);
		void push(const_reference);
		void pop();

	private:
		Container *container;

	};

	template <class T, class Container>
	stack<T, Container>::stack()
	{
		container = new Container();
	}

	template <class T, class Container>
	bool stack<T, Container>::empty()
	{
		return container->empty();
	}

	template <class T, class Container>
	size_t stack<T, Container>::size()
	{
		return container->size();
	}

	template <class T, class Container>
	typename stack<T, Container>::reference stack<T, Container>::top()
	{
		return container->back();
	}

	template <class T, class Container>
	typename stack<T, Container>::const_reference stack<T, Container>::top() const
	{
		return container->back();
	}

	template <class T, class Container>
	void stack<T, Container>::push(reference item)
	{
		return container->push_back(item);
	}

	template <class T, class Container>
	void stack<T, Container>::push(const_reference item)
	{
		return container->push_back(item);
	}

	template <class T, class Container>
	void stack<T, Container>::pop()
	{
		container->pop_back();
	}
}
