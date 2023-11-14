ASM = nasm
SRC_DIR = src
BUILD_DIR = build

all: clean setup_dirs bootloader floppy_image

setup_dirs:
	mkdir -p build

floppy_image: $(BUILD_DIR)/main_floppy.img
$(BUILD_DIR)/main_floppy.img: $(BUILD_DIR)/main.bin
	cp $< $@
	truncate -s 1440k $@

bootloader: $(BUILD_DIR)/main.bin
$(BUILD_DIR)/main.bin: $(SRC_DIR)/main.asm
	$(ASM) $(SRC_DIR)/main.asm -f bin -o $@

run: $(BUILD_DIR)/main_floppy.img
	qemu-system-i386 -fda $<

clean:
	rm -f $(BUILD_DIR)/main_floppy.img $(BUILD_DIR)/main.bin
