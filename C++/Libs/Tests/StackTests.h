#pragma once
#include "Stack.h"  
#include "gtest/gtest.h"  

class StackTests : public ::testing::Test
{
public:
	int N = 100;
	containers::stack<int> stack;
};
TEST_F(StackTests, CreateEmpty)
{
	containers::stack<int> stack;
	ASSERT_TRUE(stack.empty());
	ASSERT_EQ(0, stack.size());
}
TEST_F(StackTests, Pushing)
{
	stack.push(0);
	stack.push(1);
	stack.push(2);
	stack.push(3);
	stack.push(4);
	ASSERT_EQ(5, stack.size());
	ASSERT_EQ(4, stack.top());
}
TEST_F(StackTests, PushAndPop)
{
	stack.push(0);
	stack.pop();
	ASSERT_TRUE(stack.empty());
	for (int i = 0; i < N;++i)
	{
		stack.push(i);
		ASSERT_EQ(i, stack.top());
		stack.pop();
	}
}