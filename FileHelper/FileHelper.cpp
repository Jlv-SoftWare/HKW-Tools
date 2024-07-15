#include "FileHelper.h"

using namespace std;
namespace fs = filesystem;

int FileHelper::Upload(const string& adbPath, const string deviceID, const vector<string>& childs, const string& saveDirOnDevice)
{
	short jobResult = 0;
	for (string child : childs)
	{
		string fileName = fs::path(child).filename().string();
		string uploadPath = fs::path(saveDirOnDevice).append(fileName).string();
		string command = adbPath + " -s " + deviceID + " push \"" + child + "\" \"" + uploadPath + "\"";
		int commandresult = system(command.c_str());
		jobResult = jobResult != commandresult ? commandresult : jobResult;
	}
	return jobResult;
}

int FileHelper::Download(const string& adbPath, const string& deviceID, const vector<string>& childsOnDevice, const string& saveDir)
{
	short jobResult = 0;
	for (string childOnDevice : childsOnDevice)
	{
		string fileName = fs::path(childOnDevice).filename().string();
		string downLoadPath = fs::path(saveDir).append(fileName).string();
		string command = adbPath + " -s " + deviceID + " pull \"" + childOnDevice + "\" \"" + saveDir + "\"";
		int commandresult = system(command.c_str());
		jobResult = jobResult != commandresult ? commandresult : jobResult;
	}
	return jobResult;
}

int FileHelper::ReName(const string& adbPath, const string& deviceID, const string& childPath, const string& newName)
{
	string newFilePath = fs::path(childPath).parent_path().string() + "/" + newName;
	string command = adbPath + " -s " + deviceID + " shell mv -vf \"" + childPath + "\" \"" + newFilePath + "\"";
	return system(command.c_str());
}

int FileHelper::Copy(const string& adbPath, const string& deviceID, const string& SOURCE, const string& DEST)
{
	string command = adbPath + " -s " + deviceID + " shell cp -vf " + SOURCE + " " + DEST;
	return system(command.c_str());
}

int FileHelper::Move(const string& adbPath, const string& deviceID, const string& SOURCE, const string& DEST)
{
	string command = adbPath + " -s " + deviceID + " shell mv -vf " + SOURCE + " " + DEST;
	return system(command.c_str());
}

int FileHelper::MakeDir(const string& adbPath, const string& deviceID, const string& newDirPath)
{
	string command = adbPath + " -s " + deviceID + " shell mkdir " + newDirPath;
	return system(command.c_str());
}

int FileHelper::Delete(const string& adbPath, const string& deviceID, const string& SOURCE)
{
	string command = adbPath + " -s " + deviceID + " shell rm -rf " + SOURCE;
	return system(command.c_str());
}

int FileHelper::ShowChilds(const string& adbPath, const string& deviceID, const string& dirPath)
{
	string command = adbPath + " -s " + deviceID + " shell ls " + dirPath;
	return system(command.c_str());
}

bool FileHelper::IsDir(const string& adbPath, const string& deviceID, const string& dirPath)
{
	string command = adbPath + " -s " + deviceID + " shell [ -d \"" + dirPath + "\" ] && echo 0|| echo 1";
	string commandresult = Exec(command);
	return commandresult == "0\n";
}

vector<string> FileHelper::GetChilds(const string& adbPath, const string& deviceID, const string& dirPath)
{
	string command = adbPath + " -s " + deviceID + " shell ls " + dirPath;
	return SplitString(Exec(command), '\n');
}

vector<string> FileHelper::SplitString(const string& s, char delimiter)
{
	vector<string> tokens; string token;
	istringstream tokenStream(s);

	while (getline(tokenStream, token, delimiter))
	{
		tokens.push_back(token);
	}

	return tokens;
}

string FileHelper::RealSTR(const string& str)
{
	string result = "";
	for (char c : str)
	{
		switch (c)
		{
		case '\n':
			result += "\\n";
			break;
		case '\t':
			result += "\\t";
			break;
		case '\r':
			result += "\\r";
			break;
		case '\\':
			result += "\\\\";
			break;
		case '\"':
			result += "\\\"";
			break;
		case '\'':
			result += "\\\'";
			break;
		default:
			result += c;
			break;
		}
	}
	return result;
}

string FileHelper::Exec(const string& command)
{
	FILE* pipe = _popen(command.c_str(), "r");
	if (!pipe)
	{
		return "error";
	}
	char buffer[128];
	string result{ "" };
	while (!feof(pipe))
	{
		if (fgets(buffer, 128, pipe) != NULL)
		{
			result += buffer;
		}
	}
	_pclose(pipe);
	return result;
}

long long FileHelper::Hash(const string& str)
{
	long long hash = 0;
	for (char ch : str)
	{
		hash = hash * 31 + ch;
	}
	return hash;
}