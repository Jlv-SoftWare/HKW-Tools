#include <iostream>
#include <filesystem>
#include <sstream>
#include "FileHelper.h"

using namespace std;
namespace fs = filesystem;

static string ToLower(const string& str);

int main(int argc, char* argv[])
{
	static const vector<string> args(argv, argv + argc);

	vector<string> childs, childsOnDevice;
	const string adbPath = args[1], deviceID = args[2];
	string childPath, saveDir, saveDirOnDevice, newName, newDir, dirPath, type;
	int jobResult = 0;
	switch (FileHelper::Hash(ToLower(args[3])))
	{
	case 3456372225: //upload
	case 3452698: //push
		saveDirOnDevice = args.back();
		for (int i = 4; i < (int)args.size() - 1; i++)
		{
			childs.push_back(args[i]);
		}
		jobResult = FileHelper::Upload(adbPath, deviceID, childs, saveDirOnDevice);
		break;

	case 2853286103176: //download
	case 3452485: //pull
		saveDir = args.back();
		for (int i = 4; i < (int)args.size() - 1; i++)
		{
			for (int i = 4; i < (int)args.size() - 1; i++)
			{
				childsOnDevice.push_back(args[i]);
			}
			jobResult = FileHelper::Upload(adbPath, deviceID, childsOnDevice, saveDir);
		}
		break;

	case 3360372542:  //rename
		childPath = args[4];
		newName = args[5];
		jobResult = FileHelper::ReName(adbPath, deviceID, childPath, newName);
		break;

	case 3059573: //copy
	case 3181: //cp
		childPath = args[4];
		newDir = fs::path(args[5]).append(fs::path(childPath).filename().string()).string();
		jobResult = FileHelper::Copy(adbPath, deviceID, childPath, newDir);
		break;

	case 3357649: //move
	case 3497: //mv
		childPath = args[4];
		newDir = args[5];
		jobResult = FileHelper::Move(adbPath, deviceID, childPath, newDir);
		break;

	case 99616853983: //makedir
		newDir = args[4];
		jobResult = FileHelper::MakeDir(adbPath, deviceID, newDir);
		break;

	case 2959508907: //delete
	case 99339: //del
		childPath = args[4];
		jobResult = FileHelper::Delete(adbPath, deviceID, childPath);
		break;

	case 3132419663042580: //showchilds
	case 3463: //ls
		dirPath = args[4];
		jobResult = FileHelper::ShowChilds(adbPath, deviceID, dirPath);
		break;

	default:
		break;
	}

	cout << "返回代码: " << jobResult << endl;
}


static string ToLower(const string& str)
{
	string result = str; // 复制原始字符串
	transform(result.begin(), result.end(), result.begin(), [](unsigned char c) 
	{
		return std::tolower(c); // 转换为小写
	});
	return result;
}

