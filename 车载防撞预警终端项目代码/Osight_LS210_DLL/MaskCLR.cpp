#include "MaskCLR.h"
#include "Function.h"

MaskCLR::MaskCLR(System::String ^ inputFile, int* maskValue, int maskLength)
{
	//_inputFile = GlobeFunction::StringToChar(inputFile);
	_maskValue = maskValue;
	_maskLength = maskLength;
}

void MaskCLR::Run(void)
{
	Mask mask(_inputFile, _maskValue, _maskLength);
	mask.Run();
}

//char* GlobeFunction::StringToChar(String ^str)
//{
//	return (char*)(Marshal::StringToHGlobalAnsi(str)).ToPointer();
//}