#pragma once
#include <memory> 
template<typename T>
class ITree
{
protected:
	struct node;
	typedef std::unique_ptr<node> ptr;
	typedef T& reference;
	typedef const T& const_reference;
	typedef T* pointer;
	typedef const T* const_pointer;
	struct node
	{
		node() {}
		node(reference key) :key(key)
		{		}
		node(const_reference& key) :key(key)
		{		}
	private:
		T key;
	};
public:
	virtual ~ITree();
	virtual void insert(const_reference) = 0;
	virtual void insert(reference) = 0;
	virtual void remove(const_reference) = 0;
	virtual void remove(reference) = 0;
	virtual bool contains(const_reference) = 0;
	virtual bool contains(reference) = 0;
	bool isEmpty() const
	{
		return head != nullptr;
	}
	reference root()
	{
		return head->key;
	}

	const_reference root() const
	{
		return head->key;
	}

protected:
	node* head;
	size_t size;
	ITree() :head(nullptr), size(0)
	{}


};
