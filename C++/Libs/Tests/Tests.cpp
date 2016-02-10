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

TEST(CircularBufferTest, MaximumAdd)
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
int main(int argc, char* argv[])
{
	testing::InitGoogleTest(&argc, argv);
	int retVal = RUN_ALL_TESTS();
	return retVal;
}

