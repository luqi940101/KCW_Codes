#pragma once
#include <string>
typedef struct {
	int igr_a;
	int igr_b;
}IGR;

typedef struct {
	int aa_disable; /*/< authentiation adjust checking disable */
	int badtag_rej; /*/< reject packet if it is bypassed due to badtag */
	int pad_en; /*/< pad non-rejected packets up to 64B */
	int byp_ctl_sl; /*/< bypass packet if SL field does not correspond to packet len */
	int byp_ctl_v; /*/< bypass packet if V bit is set */
	int byp_ctl_sc; /*/< bypass packet if SC bit and either ES or SCB bits are set */
	int byp_ctl_ec; /*/< bypass packet if DC bits are not 00 or 11 */
	int sectag_flag; /*/< select which flag bit indicates that a SEC tag was present in pkt */
	IGR sis;
} IGR_GEN_T;

//public ref class Function
//{
//public:
//	Function(void);
//	~Function(void);
//	int menber;
//	int menberFuncAdd(int a, int b);
//	int struct_test(int port, IGR_GEN_T *igr_gen);
//	System::String^ say(System::String^ str);
//};


extern "C" __declspec(dllexport) int struct_test(int port, IGR_GEN_T *igr_gen);
extern "C" __declspec(dllexport) void char_test(const char* readchar, char* returnchar, int len);

extern "C" class __declspec(dllexport)  string_test
{
public:
	
	void _stdcall char_test(const char* readchar, char* returnchar, int len);
	

};

//extern "C" class _declspec(dllexport) Mask
//{
//public:
//	Mask(char* inputFile, int* maskValue, int maskLength);
//	virtual void Run(void);
//	~Mask(void);
//
//private:
//	char* _inputFile;
//	int* _maskValue;
//	int _maskLength;
//};

