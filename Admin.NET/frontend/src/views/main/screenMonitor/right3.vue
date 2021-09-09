<template>
  <div class="right3">
    <div class="lc1-header">
      设备使用情况
      <dv-decoration-3 style="width:200px;height:20px;" />
    </div>
    <dv-capsule-chart class="lc1-chart" :config="config" />
  </div>
</template>

<script>
  export default {
    name: 'Right3',
    data() {
      return {
        config: {
          data: [{
              name: '在线',
              value: 3000
            },
            {
              name: '离线',
              value: 1000
            },
            {
              name: '故障',
              value: 5000
            },
            {
              name: '全部',
              value: 200
            },
            {
              name: '其他',
              value: 1000
            }
          ],
          colors: ['#00baff', '#3de7c9', '#ffc530', '#FA3600', '#44934b'],
          showValue: true,
          unit: '张'
        }
      }
    }
  }
</script>

<style lang="less">
  .right3 {
    width: 100%;
    height: 100%;
    box-sizing: border-box;
    display: flex;
    flex-direction: column;
    background-color: rgba(6, 30, 93, 0.5);

    .lc1-header {
      position: absolute;
      left: 10px;
      font-size: 14px;
      top: 10px;
      color: #6BD4E0;
    }

    .lc1-chart {
      width: 98%;
      position: absolute;
      top: 20%;
      left: 1%;
      bottom: 0px;
    }
  }
</style>
