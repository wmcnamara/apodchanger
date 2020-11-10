#pragma once
#include <Windows.h>
#include <iostream>
#include <string>
#include <fstream>
#include <ostream>
extern "C" __declspec(dllexport) void SetDesktopBackground(const char* filepath)
{	
	SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, (void*)filepath, SPIF_UPDATEINIFILE);
}