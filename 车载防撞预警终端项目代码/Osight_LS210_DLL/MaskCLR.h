#pragma once
#include "Function.h"
public ref class MaskCLR
{
	private:
		char* _inputFile;
		int* _maskValue;
		int _maskLength;

	public:
		MaskCLR(System::String^ inputFile, int* maskValue, int maskLength);
		virtual void  Run(void) override;
};

