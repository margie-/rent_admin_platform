<template>
  <div class="middle3">
    <div class="bc-chart-item">
      <div class="bcci-header">门店1</div>
      <dv-active-ring-chart :config="config1" />
      <!-- <Label-Tag :config="labelConfig" /> -->
    </div>
    <dv-decoration-2 class="decoration-1" :reverse="true" style="width:5px;" />

    <div class="bc-chart-item">
      <div class="bcci-header">门店2</div>
      <dv-active-ring-chart :config="config2" />
      <!-- <Label-Tag :config="labelConfig" /> -->
    </div>

    <dv-decoration-2 class="decoration-2" :reverse="true" style="width:5px;" />

    <div class="bc-chart-item">
      <div class="bcci-header">门店3</div>
      <dv-active-ring-chart :config="config3" />
      <!-- <Label-Tag :config="labelConfig" /> -->
    </div>

    <dv-decoration-2 class="decoration-3" :reverse="true" style="width:5px;" />

    <div class="bc-chart-item">
      <div class="bcci-header">门店4</div>
      <dv-active-ring-chart :config="config4" />
      <!-- <Label-Tag :config="labelConfig" /> -->
    </div>

  </div>
</template>

<script>
  // import LabelTag from './LabelTag'

  export default {
    name: 'Middle3',
    components: {
      // LabelTag
    },
    data() {
      return {
        config1: {
          data: [{
              name: '设备',
              value: 356
            },
            {
              name: '订单数',
              value: 215
            },
            {
              name: '用户数',
              value: 90
            },
            {
              name: '营收',
              value: 317
            }
          ],
          color: ['#00baff', '#3de7c9', '#fff', '#ffc530', '#469f4b'],
          radius: '65%',
          activeRadius: '70%',
          showOriginValue: true,
          activeTimeGap: 5000,
          digitalFlopStyle: {
            fontSize: 12
          }
        },

        config2: {
          data: [{
              name: '设备',
              value: 615
            },
            {
              name: '订单数',
              value: 322
            },
            {
              name: '用户数',
              value: 198
            },
            {
              name: '营收',
              value: 80
            }
          ],
          color: ['#00baff', '#3de7c9', '#fff', '#ffc530', '#469f4b'],
          radius: '65%',
          activeRadius: '70%',
          showOriginValue: true,
          activeTimeGap: 5000,
          digitalFlopStyle: {
            fontSize: 12
          }
        },

        config3: {
          data: [{
              name: '设备',
              value: 452
            },
            {
              name: '订单数',
              value: 512
            },
            {
              name: '用户数',
              value: 333
            },
            {
              name: '营收',
              value: 255
            }
          ],
          color: ['#00baff', '#3de7c9', '#fff', '#ffc530', '#469f4b'],
          radius: '65%',
          activeRadius: '70%',
          showOriginValue: true,
          activeTimeGap: 5000,
          digitalFlopStyle: {
            fontSize: 12
          }
        },

        config4: {
          data: [{
              name: '设备',
              value: 156
            },
            {
              name: '订单数',
              value: 415
            },
            {
              name: '用户数',
              value: 90
            },
            {
              name: '营收',
              value: 210
            }
          ],
          color: ['#00baff', '#3de7c9', '#fff', '#ffc530', '#469f4b'],
          radius: '65%',
          activeRadius: '70%',
          showOriginValue: true,
          activeTimeGap: 5000,
          digitalFlopStyle: {
            fontSize: 12
          }
        }
        // labelConfig: {
        // 	data: ['收费站', '监控中心', '道路外场', '其他']
        // }
      }
    }
  }
</script>

<style lang="less">
  .middle3 {
    width: 100%;
    height: 100%;
    display: flex;
    position: relative;
    background-color: rgba(6, 30, 93, 0.5);

    .bc-chart-item {
      width: 25%;
      height: 100%;
      padding-top: 20px;
      box-sizing: border-box;
    }

    .bcci-header {
      height: 50px;
      text-align: center;
      line-height: 50px;
      font-size: 14px;
      color: #6BD4E0;
    }

    .dv-active-ring-chart {
      height: calc(~"100% - 80px");
      font-size: 5px;
    }

    .label-tag {
      height: 30px;
    }

    .active-ring-name {
      color: #6BD4E0 !important;
      font-size: 3px !important;
    }

    .decoration-1,
    .decoration-2,
    .decoration-3 {
      display: absolute;
      left: 0%;
    }
  }
</style>
