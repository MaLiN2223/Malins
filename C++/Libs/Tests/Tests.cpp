#include "gtest/gtest.h" 
#include "CircularBufferTests.h"  
#include "StackTests.h"
int main(int argc, char* argv[])
{
	testing::InitGoogleTest(&argc, argv);
	int retVal = RUN_ALL_TESTS();
	return retVal;
}