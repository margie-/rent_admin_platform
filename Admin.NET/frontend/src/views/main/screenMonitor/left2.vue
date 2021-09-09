<template>
  <div class="left2">
    <div class="lc1-header">
      营收数据
      <dv-decoration-3 style="width:200px;height:20px;" />
    </div>
    <dv-capsule-chart class="lc1-chart" :config="config" />
  </div>
</template>

<script>
  export default {
    name: 'Left2',
    data() {
      return {
        config: {
          data: [{
              name: '营收总数',
              value: 1500
            },
            {
              name: '租赁',
              value: 500
            },
            {
              name: '出售',
              value: 1000
            },
            {
              name: '其他',
              value: 1000
            }
          ],
          colors: ['#00baff', '#3de7c9', '#ffc530', '#469f4b'],
          showValue: true,
          unit: 'RMB'
        }
      }
    }
  }
</script>

<style lang="less">
  .left2 {
    width: 100%;
    //height: 100%;
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
