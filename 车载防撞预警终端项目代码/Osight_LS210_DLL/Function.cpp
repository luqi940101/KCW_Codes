#include "Function.h"
#include <string.h>

//Function::Function(void)
//{
//}
//
//
//Function::~Function(void)
//{
//}
//
//int Function::menberFuncAdd(int a, int b)
//{
//	return a + b;
//}
//
//System::String^ Function::say(System::String^ str)
//{
//	return str;
//}


int struct_test(int port, IGR_GEN_T *igr_gen)
{
	
	igr_gen->sectag_flag = 5;
	return	igr_gen->aa_disable + igr_gen->byp_ctl_v+igr_gen->sis.igr_a;
}

void char_test(const char* readchar, char* returnchar, int len) {
	int a = 1 + 1;

	//returnchar = (char*) readchar;
	//strcpy(pc, cpc);
	//strcpy_s(returnchar,sizeof("ha.txt"), "ha.txt");
	#pragma warning(disable : 4996)
	std::string str(readchar);
	std::strcpy(returnchar, str.c_str());
	//delete[] y;
	//strcpy_s(returnchar, sizeof(readchar)+1, readchar);
	//return readchar;
}


void string_test::char_test(const char* readchar, char* returnchar, int len) {
	int a = 1 + 1;

	//returnchar = (char*) readchar;
	//strcpy(pc, cpc);
	//strcpy_s(returnchar,sizeof("ha.txt"), "ha.txt");
#pragma warning(disable : 4996)
	std::string str(readchar);
	std::strcpy(returnchar, str.c_str());
	//delete[] y;
	//strcpy_s(returnchar, sizeof(readchar)+1, readchar);
	//return readchar;
}
