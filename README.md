# ORANGEOS

An x86_64 OS

# Install or update all apt-get dependencies

Must add these dependencies if available

sudo apt-get update

sudo apt-get upgrade -y

sudo apt-get install gcc -y                 # not cross

sudo apt-get install g++ -y

sudo apt-get install make -y

sudo apt-get install bison -y

sudo apt-get install flex -y

sudo apt-get install gawk -y

sudo apt-get install libgmp3-dev -y

sudo apt-get install libmpfr-dev libmpfr-doc libmpfr4 libmpfr4-dbg -y

sudo apt-get install mpc lib-mpc -y

sudo apt-get install texinfo -y            # optional

sudo apt-get install libcloog-isl-dev -y   # optional

sudo apt-get install build-essential -y

sudo apt-get install glibc-devel -y

sudo apt-get install gcc-multilib libc6-i386 -y

sudo apt-get install nasm qemu-system mtools -y

# How to build
After you install these dependencies go into the main folder and run ```make toolchain``` after it finished run ```make``` and to run it use ```make run```.

If something goes wrong in any of these steps fell free to open an issue.