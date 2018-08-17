# YoloWrapper-WPF
WPF (C#) Yolo Darknet Wrapper, This package deliver all dependencies for cpu detection. Special thanks for [Alexey](https://github.com/AlexeyAB/darknet) that make cross-platform Windows and Linux version.

# System requirment
- .NET Framework 4.6.1
- [Microsoft Visual C++ 2017 Redistributable x64](https://go.microsoft.com/fwlink/?LinkId=746572)

## Build requirements
- Visual Studio 2017

## How to use
-Just download yolov3.weights file from below address and copy into DeepLearning\Assets\Weights path, and compile both projects in Visual Studio 2017.

## Pre-Trained Dataset
Model | Cfg | Weights | Names |
--- | --- | --- | --- |
YOLOv3-416 | [yolov3.cfg](https://github.com/pjreddie/darknet/blob/master/cfg/yolov3.cfg) | [yolov3.weights](https://pjreddie.com/media/files/yolov3.weights) | [coco.names](https://github.com/pjreddie/darknet/blob/master/data/coco.names) |
YOLOv3-tiny | [yolov3-tiny.cfg](https://github.com/pjreddie/darknet/blob/master/cfg/yolov3-tiny.cfg) | [yolov3.weights](https://pjreddie.com/media/files/yolov3.weights) | [coco.names](https://github.com/pjreddie/darknet/blob/master/data/coco.names) |
YOLOv2 608x608 | [yolov2.cfg](https://github.com/pjreddie/darknet/blob/master/cfg/yolov2.cfg) | [yolov2.weights](https://pjreddie.com/media/files/yolov2.weights) | [coco.names](https://github.com/pjreddie/darknet/blob/master/data/coco.names) |
Tiny YOLO | [yolov2-tiny.cfg](https://github.com/pjreddie/darknet/blob/master/cfg/yolov2-tiny.cfg) | [yolov2-tiny.weights](https://pjreddie.com/media/files/yolov2-tiny.weights) | [voc.names](https://github.com/pjreddie/darknet/blob/master/data/voc.names) |
yolo9000 | [darknet9000.cfg](https://github.com/pjreddie/darknet/blob/master/cfg/darknet9000.cfg) | [yolo9000.weights](https://github.com/philipperemy/yolo-9000/tree/master/yolo9000-weights) | [9k.names](https://github.com/pjreddie/darknet/blob/master/data/9k.names) |
