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
	return	igr_gen->aa_disable + igr_gen->byp_ctl_v+igr_gen->sis.igr_a;
}

