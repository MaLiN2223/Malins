#include "gtest/gtest.h"
#include "CircularBuffer.h"

TEST(CircularBufferTest, CreatingEmpty)
{
	Containers::CircularBuffer<int> buffer(0);
	ASSERT_TRUE(buffer.empty());
	ASSERT_EQ(0, buffer.capacity());
	ASSERT_TRUE(buffer.full());
	ASSERT_EQ(0, buffer.size());
}
TEST(CircularBufferTest, MaximumAddFront)
{
	Containers::CircularBuffer<int> buffer(3);
	ASSERT_TRUE(buffer.empty());
	ASSERT_EQ(buffer.size(), 0);
	ASSERT_EQ(buffer.capacity(), 3);
	buffer.push_front(1);
	buffer.push_front(2);
	buffer.push_front(3);
	ASSERT_EQ(3, buffer.size());
}
TEST(CircularBufferTest, MaximumAddBack)
{
	Containers::CircularBuffer<int> buffer(3);
	ASSERT_TRUE(buffer.empty());
	ASSERT_EQ(0, buffer.size());
	ASSERT_EQ(3, buffer.capacity());
	buffer.push_back(1);
	buffer.push_back(2);
	buffer.push_back(3);
	ASSERT_EQ(3, buffer.size());
}
TEST(CircularBufferTest, RandomAccessNotOverflowedFront)
{
	Containers::CircularBuffer<int> buffer(3);
	buffer.push_front(9);
	buffer.push_front(8);
	buffer.push_front(7);
	ASSERT_EQ(7, buffer[0]);
	ASSERT_EQ(8, buffer[1]);
	ASSERT_EQ(9, buffer[2]);
	ASSERT_EQ(3, buffer.size());
}
TEST(CircularBufferTest, RandomAccessNotOverflowedBack)
{
	Containers::CircularBuffer<int> buffer(3);
	buffer.push_back(9);
	buffer.push_back(8);
	buffer.push_back(7);
	ASSERT_EQ(9, buffer[0]);
	ASSERT_EQ(8, buffer[1]);
	ASSERT_EQ(7, buffer[2]);
	ASSERT_EQ(3, buffer.size());
}
TEST(CircularBufferTest, OverMaximumAddFront)
{
	Containers::CircularBuffer<int> buffer(4);
	buffer.push_front(1);
	buffer.push_front(2);
	buffer.push_front(3);
	buffer.push_front(4);
	buffer.push_front(5);
	buffer.push_front(6);
	ASSERT_EQ(4, buffer.size());
	ASSERT_EQ(6, buffer[0]);
	ASSERT_EQ(5, buffer[1]);
	ASSERT_EQ(4, buffer[2]);
	ASSERT_EQ(3, buffer[3]);
	ASSERT_EQ(4, buffer.size());
}
TEST(CircularBufferTest, OverMaximumAddBack)
{
	Containers::CircularBuffer<int> buffer(4);
	buffer.push_back(1);
	buffer.push_back(2);
	buffer.push_back(3);
	buffer.push_back(4);
	buffer.push_back(5);
	buffer.push_back(6);
	ASSERT_EQ(4, buffer.size());
	ASSERT_EQ(3, buffer[0]);
	ASSERT_EQ(4, buffer[1]);
	ASSERT_EQ(5, buffer[2]);
	ASSERT_EQ(6, buffer[3]);
	ASSERT_EQ(4, buffer.size());
}
TEST(CircularBufferTest, PopingBack)
{
	Containers::CircularBuffer<int> buffer(4);
	buffer.push_back(1);
	buffer.push_back(2);
	buffer.push_back(3);
	buffer.push_back(4);
	ASSERT_EQ(1, buffer.front());
	ASSERT_EQ(4, buffer.back());
	buffer.pop_back();
	ASSERT_EQ(1, buffer.front());
	ASSERT_EQ(3, buffer.back());
	buffer.pop_back();
	ASSERT_EQ(1, buffer.front());
	ASSERT_EQ(2, buffer.back());
	buffer.pop_back();
	ASSERT_EQ(1, buffer.front());
	ASSERT_EQ(1, buffer.back());
	buffer.pop_back();
	ASSERT_TRUE(buffer.empty());
}
TEST(CircularBufferTest, PopingFront)
{
	Containers::CircularBuffer<int> buffer(4);
	buffer.push_back(1);
	buffer.push_back(2);
	buffer.push_back(3);
	buffer.push_back(4);
	ASSERT_EQ(1, buffer.front());
	ASSERT_EQ(4, buffer.back());
	buffer.pop_front();
	ASSERT_EQ(2, buffer.front());
	ASSERT_EQ(4, buffer.back());
	buffer.pop_front();
	ASSERT_EQ(3, buffer.front());
	ASSERT_EQ(4, buffer.back());
	buffer.pop_front();
	ASSERT_EQ(4, buffer.front());
	ASSERT_EQ(4, buffer.back());
	buffer.pop_front();
	ASSERT_TRUE(buffer.empty());
}

TEST(CircularBufferTest, Test1)
{
	Containers::CircularBuffer<int> buffer(10);
	buffer.push_back(3);
	buffer.push_back(4);
	buffer.push_back(5);
	buffer.push_front(6);
	buffer.push_front(7);
	buffer.push_front(8);
}
int main(int argc, char* argv[])
{
	testing::InitGoogleTest(&argc, argv);
	int retVal = RUN_ALL_TESTS();
	return retVal;
}