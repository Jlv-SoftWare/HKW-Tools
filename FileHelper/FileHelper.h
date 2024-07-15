#pragma once
#include <iostream>
#include <sstream>
#include <string>
#include <vector>
#include <filesystem>

using namespace std;
namespace fs = std::filesystem;

class FileHelper
{
public:
	static int Upload(const string& adbPath, const string deviceID, const vector<string>& childs, const string& saveDirOnDevice);

	static int Download(const string& adbPath, const string& deviceID, const vector<string>& childsOnDevice, const string& saveDir);

	static int Copy(const string& adbPath, const string& deviceID, const string& SOURCE, const string& DEST);

	static int Move(const string& adbPath, const string& deviceID, const string& SOURCE, const string& DEST);

	static int ReName(const string& adbPath, const string& deviceID, const string& childPath, const string& newName);

	static int MakeDir(const string& adbPath, const string& deviceID, const string& newDirPath);

	static int Delete(const string& adbPath, const string& deviceID, const string& SOURCE);

	static int ShowChilds(const string& adbPath, const string& deviceID, const string& dirPath);

	static vector<string> GetChilds(const string& adbPath, const string& deviceID, const string& dirPath);

	static bool IsDir(const string& adbPath, const string& deviceID, const string& dirPath);

	static long long Hash(const string& str);

private:
	static string Exec(const string& command);

	static string RealSTR(const string& str);

	static vector<string> SplitString(const string& s, char delimiter);
};
