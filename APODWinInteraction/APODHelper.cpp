#pragma once
#include <Windows.h>

extern "C" __declspec(dllexport) void SetDesktopBackground(const char* filepath)
{	
	SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, (void*)filepath, SPIF_UPDATEINIFILE);
}