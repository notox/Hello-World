#include <iostream>
#include <string>

using namespace std;

class CPU
{
public:
    CPU():id(0)
    {
    }
    virtual void Run()
    {
    }
    string GetName()
    {
        return name;
    }
private:
    int id;
    string name;
};

class IntelCPU : public CPU
{
public:
    virtual void Run()
    {
    }
};

class AMD
{
public:
    virtual void Build()
    {
    }
};

class AMDCPU : public CPU, public AMD
{
public:
    virtual void Run()
    {
    }
    virtual void Build()
    {
    }
};

int main()
{
    CPU* cpu = new CPU;
    cout << "cpu address: " << cpu << endl;
    cout << "cpu size: " << sizeof(CPU) << endl;
    cpu->GetName();
    cpu->Run();

    IntelCPU* intelCPU = new IntelCPU;
    cout << "intel cpu address: " << intelCPU << endl;
    cout << "intel cpu size: " << sizeof(IntelCPU) << endl;
    intelCPU->GetName();
    intelCPU->Run();

    cpu = intelCPU;
    cout << "intel cpu (CPU) address: " << intelCPU << endl;
    cpu->GetName();
    cpu->Run();

    AMDCPU* amdCPU = new AMDCPU;
    cout << "amd cpu address: " << amdCPU << endl;
    cout << "amd cpu size: " << sizeof(AMDCPU) << endl;

    cpu = amdCPU;
    cout << "amd cpu (CPU) address: " << cpu << endl;

    AMD* amd = amdCPU;
    cout << "amd cpu (AMD) address: " << amd << endl;
}