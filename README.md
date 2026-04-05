# SSD1306 OLED Driver in Forth (RP2040)

A lightweight, low-level I2C driver for SSD1306 OLED displays written in the Forth programming language. This project is designed for the Raspberry Pi Pico (RP2040) using the Mecrisp-Stellaris Forth interpreter.

## Hardware Wiring

Connect your OLED to the Pico as follows:

| OLED Pin | Pico Pin | Physical Pin |
| :--- | :--- | :--- |
| **VCC** | 3.3V (OUT) | Pin 36 |
| **GND** | GND | Pin 38 |
| **SDA** | GP4 (I2C0 SDA) | Pin 6 |
| **SCL** | GP5 (I2C0 SCL) | Pin 7 |

## Setup Instructions

### 1. Prepare the Pico
1. Download the `mecrisp-stellaris-rp2040.uf2` firmware.
2. Hold the **BOOTSEL** button on your Pico and connect it to your PC.
3. Drag and drop the `.uf2` file into the RPI-RP2 drive.

### 2. Connect via Serial Terminal
Use a tool like **PuTTY** or **Tera Term**:
- **Baud Rate:** 115200
- **Data Bits:** 8
- **Stop Bits:** 1

### 3. Load and Run the Driver
1. Copy the code from `oled_driver.fs`.
2. Paste it into your terminal window.
3. Type the following commands to initialize and display text:

```forth
4 5 i2c-setup  \ Initialize I2C on Pins 4 and 5
oled-init      \ Power on the display
oled-clear     \ Clear the screen buffer
say-hi         \ Display "HI" on the OLED
